using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using RefraGama.Core;


namespace RefraGama.Seismogram
{
     /// <summary>
    /// Class WaveformViewer.
    /// </summary>
    /// <seealso cref="DevExpress.XtraEditors.XtraUserControl" />
    public partial class WaveformViewer : XtraUserControl
    {
        /// <summary>
        /// Our main panel
        /// </summary>
        private ILPanel _ilPanel;

        /// <summary>
        /// Our starting datetime reference, or the earliest datetime from all traces in this viewer
        /// </summary>
        private DateTime _referenceStartTime;

        /// <summary>
        /// The time delta for one unit indices in this viewer. Caution: This may be different with the original signal.
        /// </summary>
        private float _referenceDt;

        /// <summary>
        /// Our payload stream, a copy of the original stream or can be used as temporary stream for processing.
        /// </summary>
        private ISeismicStream _stream;

        /// <summary>
        /// Collection of time windows used to generate rectangle window overlay on this viewer
        /// </summary>
        private List<TimeWindow> _timeWindows;


        /// <summary>
        /// time range of plotted data
        /// </summary>
        private float _dataTimeRange;

        /// <summary>
        /// amplitude range of plotted data
        /// </summary>
        private float _dataAmpRange;

        /// <summary>
        /// toggle delete window action (default false)
        /// </summary>
        private bool _delWindowActive;

        /// <summary>
        /// toggle add window action (default false)
        /// </summary>
        private bool _addWindowActive;


        /// <summary>
        /// Delegate CutMarkerDrawnHandler
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public delegate void CutMarkerDrawnHandler(DateTime start, DateTime end);

        /// <summary>
        /// Callback on CutMarkerDrawnHandler
        /// </summary>
        public CutMarkerDrawnHandler OnCutMarkerDrawn;

        private bool _cutlineActive;
        private float[] _cutlineValue;
        private Cutline _selectedCutline = Cutline.StartLine;
        enum Cutline
        {
            StartLine, EndLine
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WaveformViewer"/> class.
        /// </summary>
        public WaveformViewer()
        {
            InitializePanel();
            InitializeComponent();
            _ilPanel.Visible = false;
        }

        /// <summary>
        /// Redraw current time windows and change the color in correct order to bounds with waveformviewer curves color
        /// </summary>
        public void RefreshWindowsColor()
        {
            _timeWindows.Sort();
            DrawTimeWindows(GetTimeWindow().ToArray());
        }

        /// <summary>
        /// Get selected time window on the waveform viewer
        /// </summary>
        /// <returns>Selected time window</returns>
        public List<TimeWindow> GetTimeWindow()
        {
            _timeWindows?.Sort();
            return _timeWindows;
        }

        /// <summary>
        /// Enable/disable delete window tool
        /// </summary>
        /// <param name="enable">true means enable delete window tool</param>
        public void DeleteWindow(bool enable)
        {
            _delWindowActive = enable;
        }

        /// <summary>
        /// Enable/disable add window tool
        /// </summary>
        /// <param name="enable">true means enable delete window tool</param>
        public void AddWindow(bool enable)
        {
            _addWindowActive = enable;
        }

        /// <summary>
        /// Updates the viewer to display the new specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void UpdatePayload(ISeismicStream stream)
        {
            //reset waveform viewer control
            zoomTrackBarControl1.Value = 0;
            zoomTrackBarControl2.Value = 0;
            hScrollBar1.Value = 0;
            _timeWindows = null;

            _ilPanel.Visible = true;
            _stream = MakeCopy(stream);


            _referenceStartTime = DateTime.MaxValue;
            foreach (var trace in stream.Traces)
            {
                if (trace.Header.StartTime >= _referenceStartTime) continue;
                _referenceStartTime = trace.Header.StartTime;
                _referenceDt = trace.Header.Delta;
            }

            var scene = CreatePlotCubes(_stream.Count);
            AddPlot(scene,stream);

            
            _ilPanel.Scene = scene;
            _ilPanel.Configure();
            Refresh();

            InitiateDeleteWindowsTool();
        }


        /// <summary>
        /// Should the inner stream payload changes, use this to reflect the changes.
        /// </summary>
        public void RefreshPayload()
        {
            UpdatePayload(_stream);
        }


        /// <summary>
        /// Gets the inner stream.
        /// </summary>
        /// <returns>ISeismicStream.</returns>
        public ISeismicStream GetInnerStream()
        {
            return _stream;
        }

#region everything about cutline tool

        public DateTime[] GetCutlineValue()
        {
            var cutlineValue = new DateTime[2];
            var startLineTime = _referenceStartTime + TimeSpan.FromSeconds(_cutlineValue[0]*_referenceDt);
            var endLineTime = _referenceStartTime + TimeSpan.FromSeconds(_cutlineValue[1]*_referenceDt);      
            if (_cutlineValue[0] > _cutlineValue[1])
            {
                var temp = startLineTime;
                startLineTime = endLineTime;
                endLineTime = temp;
            }
            cutlineValue[0] = startLineTime;
            cutlineValue[1] = endLineTime;
            return cutlineValue;
        }

        /// <summary>
        /// Draw Cutline for cut tools
        /// </summary>
        public void DrawCutline()
        {
            // in case there's already overlays, we need to clear it first
            ClearPreviousWindowsOverlay();
            ClearPreviousCutlineOverlay();

            _cutlineValue = new float[2];
            _cutlineValue[0] = 0;
            _cutlineValue[1] = _dataTimeRange;

            foreach (var cube in GetPlotCubes())
            {
                var cutlineGroup = new ILGroup(cube.Tag + "cutline");
                var tag = $"{cube.Tag}";
                AddCutlineOverlay(cutlineGroup, tag + "StartLine");
                AddCutlineOverlay(cutlineGroup, tag + "EndLine");
                cube.Axes.Parent.Add(cutlineGroup);
            }

            SetCutlineOverlayPosition();

            // all set, reflect the changes please
            _ilPanel.Configure();
            InitiateCutlineTool();
        }

        
        /// <summary>
        /// Set Cut line position in the viewer
        /// </summary>
        /// <param name="xAxisposition">X axis position</param>
        /// <param name="cutlineType">Type of the cutline</param>
        /// <param name="initiation">true to initiate and flase to move the cutline</param>
        private void SetCutlineOverlayPosition(float xAxisposition, Cutline cutlineType, bool initiation = false)
        {
            if (_cutlineValue == null) return;
            foreach (var cube in GetPlotCubes())
            {
                var overlays = GetWindowOverlay(cube);
                var theoverlay = overlays as ILGroup[] ?? overlays.ToArray();

                // the actual position we are going to place the rectangle
                var x1 = (_stream.GetEndDateTime() - _referenceStartTime).TotalSeconds / _referenceDt;

                // recompute the overlay group transform: scaling and translation
                float w = cube.Limits.WidthF, min = cube.Limits.XMin;

                if (theoverlay.ElementAt(0) != null && (cutlineType == Cutline.StartLine || initiation))
                {
                    _cutlineValue[0] = (int) xAxisposition;
                    var startLine = theoverlay.ElementAt(0);
                    startLine.Transform = Matrix4.ScaleTransform(0.002f, 1, 1).Translate((xAxisposition - min) / w, 0, .9999);
                }

                if (theoverlay.ElementAt(1) != null && (cutlineType == Cutline.EndLine || initiation))
                {
                    
                    var endLine = theoverlay.ElementAt(1);
                    if (initiation)
                    {
                        endLine.Transform = Matrix4.ScaleTransform(0.002f, 1, 1).Translate((x1 - min) / w, 0, .9999);
                        _cutlineValue[1] = (int) _dataTimeRange;
                    }
                        
                    else
                    {
                        endLine.Transform = Matrix4.ScaleTransform(0.002f, 1, 1).Translate((xAxisposition - min) / w, 0, .9999);
                        _cutlineValue[1] = (int) xAxisposition;
                    }
                        
                }
            }
            _ilPanel.Configure();
            Refresh();
        }

        private void SetCutlineOverlayPosition()
        {
            SetCutlineOverlayPosition(0, Cutline.StartLine, true);
        }

        public void UpdateCutline(DateTime start, DateTime end)
        {
            var startX = (float) (start - _referenceStartTime).TotalSeconds/_referenceDt;
            var endX = (float) (end - _referenceStartTime).TotalSeconds/_referenceDt;
            SetCutlineOverlayPosition(startX,Cutline.StartLine);
            SetCutlineOverlayPosition(endX,Cutline.EndLine);
        }

        /// <summary>
        /// Add Cut line overlay over the IL Scene
        /// </summary>
        /// <param name="group"></param>
        /// <param name="tag"></param>
        private void AddCutlineOverlay(ILGroup group, string tag)
        {
            // the overlay will be a rectangular ILTriangles shape... 
            var rect = Shapes.RectangleFilled;
            rect.Color = Color.Orange;


            // It is more convenient to place the overlay in the same group as 
            // the axes objects (the group will be added to axes parent). The coord system there always runs from 0...1 
            // which makes it easy to recompute the overlay extent. However, 
            // in order to access that group, we cannot use plotCube.Children or 
            // plotCube.Add, since this would add the objects as new plot object. 
            // Hence we locate the target group as the parent of the axis collection. 
            group.Children.Add(
                // The overlay is added into a seperate group node. We use 
                // it in order to realize clipping which prevents the overlay 
                // to run out of the plotcube on interactive pan operations
                new ILGroup("ClipGroup")
                {
                    Clipping = new ILClipParams()
                    {
                        // since the overlay will only move in x direction, 
                        // it is sufficient to add clipping planes for the 
                        // horizontal limits only. 
                        Plane0 = new Vector4(-1, 0, 0, 1f),
                        Plane1 = new Vector4(1, 0, 0, 0),
                    },
                    Children =
                    {
                        // Put the actual rectangle overlay shape into another group node.
                        // This one will be responsible for all transformations: size and position. 
                        // It is the one which will be retrieved via the tag identifier later. 
                        // We use target: Screen2DNear for the group. This is only needed,
                        // in order to display the overlay on top of the markers also. Keep
                        // in mind: markers are 2DFar objects, hence without defining a 
                        // render target here, the markers would go on top of the overlay. 
                        new ILGroup(tag, target: RenderTarget.Screen2DNear)
                        {
                            // add the overlay rectangle here
                            rect,
                        }
                    }
                });
        }

        /// <summary>
        /// Change Cutline color to indicate activated cutline
        /// </summary>
        private void ChangeCutlineColor(Cutline cutlineType)
        {
            foreach (var cube in GetPlotCubes())
            {
                var overlays = GetWindowOverlay(cube);
                var theoverlay = overlays as ILGroup[] ?? overlays.ToArray();
                var theCutline = theoverlay.ElementAt(cutlineType == Cutline.StartLine ? 0 : 1);

                theCutline.ColorOverride = _cutlineActive ? Color.Magenta : Color.Orange;
                
            }
        }

        /// <summary>
        /// Clear Cutline from IL Scene
        /// </summary>
        public void ClearCutlineTool()
        {
            ClearPreviousCutlineOverlay();
        }

        /// <summary>
        /// Clear Cutline from IL Scene
        /// </summary>
        private void ClearPreviousCutlineOverlay()
        {
            foreach (var cube in GetPlotCubes())
            {
                if (cube.Axes.Parent.Children.Count < 4) return;
                cube.Axes.Parent.Children.RemoveAt(3);
            }
            _timeWindows = null;
            _cutlineValue = null;

        }

        #endregion

        #region everything about time windows

        /// <summary>
        /// Draw single time window
        /// </summary>
        /// <param name="timeWindow">the time window to be draw</param>
        public void DrawTimeWindows(TimeWindow timeWindow)
        {
            foreach (var cube in GetPlotCubes())
            {
                var tag = $"{cube.Tag}_{timeWindow.StartPosition}";
                var axesParent = cube.Axes.Parent;
                var rectgroup = (ILGroup)axesParent.Children[3];
                var color = Color.FromArgb(60,Color.SlateGray);
                AddRectangleOverlay(rectgroup, tag, color);
            }

            // the added rectangle overlay has not been positioned to their corresponding place
            // so we set all their position inside the method
            SetSingleWindowPosition();

            // all set, reflect the changes please
            _ilPanel.Configure();
            Refresh();
        }

        /// <summary>
        /// Draw rectangle overlay(s) representing the given time window(s).
        /// </summary>
        /// <param name="timeWindows">The time windows.</param>
        public void DrawTimeWindows(params TimeWindow[] timeWindows)
        {
            // in case there's already overlays, we need to clear it first
            ClearPreviousWindowsOverlay();

            // update our inner time window collection
            _timeWindows = timeWindows.ToList();

            // casting time window collection to list for convenience use
            var enumerable = _timeWindows as IList<TimeWindow> ?? _timeWindows.ToList();

            /* okay here we loop to each cubes in this scene,
             * in each cube we iterate over the time window and draw a rectangle overlay on the cube
             * each rectangle overlay is given a 'name tag' for an easier reference later
             * the name tag is given as <cube_tag>_<indexPosition_of_the_current_time_window>
             * each rectangle overlay is given unique color based on our colormap above
             */
            foreach (var cube in GetPlotCubes())
            {
                var rectGroup = new ILGroup(cube.Tag + "rectgroup");
                
                foreach (var window in enumerable)
                {
                    var tag = $"{cube.Tag}_{window.StartPosition}";
                    AddRectangleOverlay(rectGroup, tag);
                }

                cube.Axes.Parent.Add(rectGroup);
            }

            // the added rectangle overlay has not been positioned to their corresponding place
            // so we set all their position inside the method
            SetWindowOverlayPosition();

            // all set, reflect the changes please
            _ilPanel.Configure();
            Refresh();
        }

        /// <summary>
        /// Clears the time windows overlay.
        /// </summary>
        public void ClearTimeWindows()
        {
            ClearPreviousWindowsOverlay();
            _ilPanel.Configure();
            Refresh();
        }


        /// <summary>
        /// Removes the time window at the specified seconds since reference time.
        /// </summary>
        /// <param name="xAxisPosition">The x axis position</param>
        public void RemoveTimeWindowAt(float xAxisPosition)
        {
            if (_timeWindows == null) return;
            var secondsSinceT0 = xAxisPosition*_referenceDt;
            var targetIndex = 0;
            var targetHit = false;
            for (var i = 0; i < _timeWindows.Count; i++)
            {
                var tw = _timeWindows[i];
                // ReSharper disable once InvertIf
                if (secondsSinceT0 >= tw.SecondsSinceT0 && 
                    secondsSinceT0 <= tw.SecondsSinceT0 + tw.Duration)
                {
                    targetIndex = i;
                    targetHit = true;
                    break;
                }
            }
            
            if (!targetHit) return;
            _timeWindows.RemoveAt(targetIndex);
            RemoveTimeWindowOverlayAt(targetIndex);
            _ilPanel.Configure();
            //Refresh();
        }


        /// <summary>
        /// Add the time window at the specified seconds since reference time
        /// </summary>
        /// <param name="xAxisPosition">The x axis positon</param>
        public void AddTimeWindowAt(float xAxisPosition)
        {
            if (_timeWindows == null) return;
            var secondsSinceT0 = xAxisPosition*_referenceDt;
            var referenceTw = _timeWindows[0];
            var targetHit = false;
            for (var i = 0; i < _timeWindows.Count; i++)
            {
                var tw = _timeWindows[i];
                // ReSharper disable once InvertIf
                if (secondsSinceT0 >= tw.SecondsSinceT0 &&
                    secondsSinceT0 <= tw.SecondsSinceT0 + tw.Duration)
                {
                    targetHit = true;
                    break;
                }

            }

            if(targetHit) return;
            var stepIndex = (int) (secondsSinceT0/referenceTw.Duration)*(int) referenceTw.Duration; 
            var newTw = new TimeWindow(referenceTw.DeltaTime, (int) (stepIndex / referenceTw.DeltaTime), referenceTw.Length);
            _timeWindows.Add(newTw);
            DrawTimeWindows(newTw);
            _ilPanel.Configure();
        }

        /// <summary>
        /// Removes the time window overlay at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        private void RemoveTimeWindowOverlayAt(int index)
        {
            foreach (var cube in GetPlotCubes())
            {
                var rectGroup = (ILGroup) cube.Axes.Parent.Children[3];
                rectGroup.Children.RemoveAt(index);
                
            }
        }

        /// <summary>
        /// Clears the previous windows overlay. 
        /// Only changes the buffer but not reflected on the control
        /// </summary>
        private void ClearPreviousWindowsOverlay()
        {
            if (_timeWindows == null)
                return;
            foreach (var cube in GetPlotCubes())
            {
                cube.Axes.Parent.Children.RemoveAt(3);
            }
            _timeWindows = null;
        }


        /// <summary>
        /// Adds the rectangle overlay.
        /// </summary>
        /// <param name="group">The rectangle group overlay</param>
        /// <param name="tag">The tag.</param>
        /// <param name="color">The color.</param>
        private static void AddRectangleOverlay(ILGroup group, string tag, Color color)
        {
            // the overlay will be a rectangular ILTriangles shape... 
            var rect = Shapes.RectangleFilled;
            rect.Color = color;

            // gotta give them rectangle a border lines
            var rectLine = Shapes.RectangleWireframe;
            rectLine.Color = Color.FromArgb(50, color);
            

            // It is more convenient to place the overlay in the same group as 
            // the axes objects (the group will be added to axes parent). The coord system there always runs from 0...1 
            // which makes it easy to recompute the overlay extent. However, 
            // in order to access that group, we cannot use plotCube.Children or 
            // plotCube.Add, since this would add the objects as new plot object. 
            // Hence we locate the target group as the parent of the axis collection. 
            group.Children.Add(
                // The overlay is added into a seperate group node. We use 
                // it in order to realize clipping which prevents the overlay 
                // to run out of the plotcube on interactive pan operations
                new ILGroup("ClipGroup")
                {
                    Clipping = new ILClipParams()
                    {
                        // since the overlay will only move in x direction, 
                        // it is sufficient to add clipping planes for the 
                        // horizontal limits only. 
                        Plane0 = new Vector4(-1, 0, 0, 1f),
                        Plane1 = new Vector4(1, 0, 0, 0),
                    },
                    Children =
                    {
                        // Put the actual rectangle overlay shape into another group node.
                        // This one will be responsible for all transformations: size and position. 
                        // It is the one which will be retrieved via the tag identifier later. 
                        // We use target: Screen2DNear for the group. This is only needed,
                        // in order to display the overlay on top of the markers also. Keep
                        // in mind: markers are 2DFar objects, hence without defining a 
                        // render target here, the markers would go on top of the overlay. 
                        new ILGroup(tag, target: RenderTarget.Screen2DNear)
                        {
                            // add the overlay rectangle here
                            rect,
                            rectLine
                        }
                    }
                });
        }

        private static void AddRectangleOverlay(ILGroup group, string tag)
        {
            var color = Color.FromArgb(60, Color.SlateGray);
            AddRectangleOverlay(group,tag,color);
        }

        /// <summary>
        /// Gets the window overlay. 
        /// CAUTION: Do not call this method when you haven't added a window overlay
        /// </summary>
        /// <param name="cube">The cube.</param>
        /// <returns>IEnumerable&lt;ILGroup&gt;.</returns>
        private static IEnumerable<ILGroup> GetWindowOverlay(ILPlotCube cube)
        {
            var axesParent = cube.Axes.Parent;
            var rectgroup = (ILGroup) axesParent.Children[3];


            foreach (var child in rectgroup.Children)
            {
                yield return (ILGroup) child;
            }
            
        }

        /// <summary>
        /// Sets the window overlay position to their respectinve time window position.
        /// </summary>
        private void SetWindowOverlayPosition()
        {
            var timeWindow = _timeWindows.ToArray();
            foreach (var cube in GetPlotCubes())
            {
                var windowId = 0;
                var overlays = GetWindowOverlay(cube);
                foreach (var rectOverlay in overlays)
                {
                    // the actual position we are going to place the rectangle
                    var x1 = timeWindow[windowId].SecondsSinceT0 / _referenceDt;
                    var x2 = (timeWindow[windowId].SecondsSinceT0 + timeWindow[windowId].Duration) / _referenceDt;
                    
                    // recompute the overlay group transform: scaling and translation
                    float w = cube.Limits.WidthF, min = cube.Limits.XMin;
                    // The group content is still its initial size: a rectangle spanning from 0..1 in X and Y. 
                    // Scaling and translation is done in the group holding the rectangle shape. The task 
                    // is to translate from the 'true' data values given in X1 and x2 to the coordinate 
                    // system, the rectangle lives in: 0..1. 
                    // First the content is scaled in X according to the needed range. 
                    // Then the area is moved to the correct position. 
                    if (rectOverlay != null)
                        rectOverlay.Transform = Matrix4.ScaleTransform((x2 - x1) / w, 1, 1).Translate((x1 - min) / w, 0, .9999);

                    windowId++;
                }
            }
        }

        private void SetSingleWindowPosition()
        {
            var timeWindow = _timeWindows.ToArray();
            foreach (var cube in GetPlotCubes())
            {
                var overlays = GetWindowOverlay(cube);
                var enumerable = overlays as ILGroup[] ?? overlays.ToArray();
                var lastRectOverlay = enumerable.ElementAt(enumerable.Count()-1);
                var x1 = timeWindow[enumerable.Count() - 1].SecondsSinceT0 / _referenceDt;
                var x2 = (timeWindow[enumerable.Count() - 1].SecondsSinceT0 + timeWindow[enumerable.Count() - 1].Duration) / _referenceDt;

                // recompute the overlay group transform: scaling and translation
                float w = cube.Limits.WidthF, min = cube.Limits.XMin;
                // The group content is still its initial size: a rectangle spanning from 0..1 in X and Y. 
                // Scaling and translation is done in the group holding the rectangle shape. The task 
                // is to translate from the 'true' data values given in X1 and x2 to the coordinate 
                // system, the rectangle lives in: 0..1. 
                // First the content is scaled in X according to the needed range. 
                // Then the area is moved to the correct position. 
                if (lastRectOverlay != null)
                    lastRectOverlay.Transform = Matrix4.ScaleTransform((x2 - x1) / w, 1, 1).Translate((x1 - min) / w, 0, .9999);
            }
        }

#endregion
        /// <summary>
        /// Return a clone of given stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>ISeismicStream.</returns>
        private static ISeismicStream MakeCopy(ISeismicStream stream)
        {
            /* Make a copy */
            var traces = stream.Traces.Select(seismicTrace => seismicTrace.Clone()).ToList();
            return new SeismicStream(traces);
        }

        /// <summary>
        /// Gets the plot cubes in the current scene.
        /// </summary>
        /// <returns>IReadOnlyList&lt;ILPlotCube&gt;.</returns>
        private IReadOnlyList<ILPlotCube> GetPlotCubes()
        {
            var result = new List<ILPlotCube>();

            foreach (var child in _ilPanel.Scene.Children)
            {
                if (child.GetType() == typeof(ILPlotCube))
                {
                    result.Add(child as ILPlotCube);
                }
            }
            return result;
        }


        /// <summary>
        /// Gets the plot cubes in the given scene.
        /// </summary>
        /// <param name="scene">The scene.</param>
        /// <returns>IReadOnlyList&lt;ILPlotCube&gt;.</returns>
        public static IReadOnlyList<ILPlotCube> GetPlotCubes(ILGroup scene)
        {
            var result = new List<ILPlotCube>();

            foreach (var child in scene.Children)
            {
                if (child.GetType() == typeof(ILPlotCube))
                {
                    result.Add(child as ILPlotCube);
                }
            }
            return result;
        }

        /// <summary>
        /// Adds the plot to the scene. Scene must have the same number of plot cube as the number of traces in stream
        /// </summary>
        /// <param name="scene">scene to add plot into</param>
        /// <param name="stream1">The stream1.</param>
        /// <param name="stream2">The stream2.</param>
        private void AddComparePlot(ILGroup scene, ISeismicStream stream1, ISeismicStream stream2)
        {
            // access cube
            var cubes = GetPlotCubes(scene);

            for (var i = 0; i < cubes.Count; i++)
            {
                using (ILScope.Enter())
                {
                    var trace1 = stream1.Traces[i];
                    var trace2 = stream2.Traces[i];
                    var cube = cubes[i];

                    /*// since ILMemoryPool take ownership of the array, we give them a copy instead.
                    var traceArrCopy = new float[trace.Count];
                    Array.Copy(trace.Data, traceArrCopy, trace.Count);
                    ILArray<float> ilArray = traceArrCopy;*/

                    // since this is reduced stream, we don't need to make another copy, just leave it to ILMemoryPool
                    ILArray<float> ilArray1 = trace1.Data;
                    ILArray<float> ilArray2 = trace2.Data;


                    // this is color coding our line plot based on the trace channel type
                    var color1 = Color.Black;
                    switch (trace1.Header.ChannelType)
                    {
                        case ChannelType.Z:
                            color1 = Color.RoyalBlue;
                            break;
                        case ChannelType.N:
                            color1 = Color.Red;
                            break;
                        case ChannelType.E:
                            color1 = Color.LimeGreen;
                            break;
                    }

                    var color2 = Color.Black;
                    switch (trace1.Header.ChannelType)
                    {
                        case ChannelType.Z:
                            color2 = Color.LimeGreen;
                            break;
                        case ChannelType.N:
                            color2 = Color.RoyalBlue;
                            break;
                        case ChannelType.E:
                            color2 = Color.Red;
                            break;
                    }

                    // -------------- Trace from stream 1 -------------------------- //
                    // if given trace has the same delta with this viewer delta reference and the same starting time
                    // we could just add the value array without the time array since it will be automatically assigned by ILLinePlot
                    if (trace1.Header.Delta.Equals(_referenceDt) && trace1.Header.StartTime.Equals(_referenceStartTime))
                    {
                        Debug.WriteLine("Sampling rate and start time equal, plotting without explicit indices");
                        var plot = cube.Add(new ILLinePlot(ilArray1));
                        plot.Line.Color = color1;
                    }

                    // if they are not, give the time array explicitly
                    else
                    {
                        Debug.WriteLine("Sampling rate and start time are not equal, plotting with explicit indices");
                        var startPosition = (trace1.Header.StartTime - _referenceStartTime).TotalSeconds / _referenceDt;
                        var steps = trace1.Header.SamplingRate * _referenceDt;
                        var timeArray = new float[trace1.Count];
                        for (var j = 0; j < trace1.Count; j++)
                        {
                            timeArray[j] = (float)startPosition + j * steps;
                        }

                        var plot = cube.Add(new ILLinePlot(timeArray, ilArray1));
                        plot.Line.Color = color1;
                    }

                    // -------------- Trace from stream 2 -------------------------- // 
                    // if given trace has the same delta with this viewer delta reference and the same starting time
                    // we could just add the value array without the time array since it will be automatically assigned by ILLinePlot
                    if (trace2.Header.Delta.Equals(_referenceDt) && trace2.Header.StartTime.Equals(_referenceStartTime))
                    {
                        Debug.WriteLine("Sampling rate and start time equal, plotting without explicit indices");
                        var plot2 = cube.Add(new ILLinePlot(ilArray2));
                        plot2.Line.Color = color2;
                    }

                    // if they are not, give the time array explicitly
                    else
                    {
                        Debug.WriteLine("Sampling rate and start time are not equal, plotting with explicit indices");
                        var startPosition = (trace2.Header.StartTime - _referenceStartTime).TotalSeconds / _referenceDt;
                        var steps = trace2.Header.SamplingRate * _referenceDt;
                        var timeArray = new float[trace2.Count];
                        for (var j = 0; j < trace2.Count; j++)
                        {
                            timeArray[j] = (float)startPosition + j * steps;
                        }

                        var plot = cube.Add(new ILLinePlot(timeArray, ilArray2));
                        plot.Line.Color = color2;
                    }

                    cube.Axes.YAxis.Label.Text = $"{trace1.Header.Station} {trace1.Header.ChannelType}";
                    cube.Axes.YAxis.Label.Font = new Font("MS Shell Dlg 2", 8.0f);
                    cube.Axes.YAxis.LabelAnchor = new PointF(0.5f, 0.5f);
                    cube.Axes.YAxis.LabelPosition = new Vector3(0.5f, 1f, 0);
                    cube.Axes.YAxis.Ticks.DefaultLabel.Font = new Font("MS Shell Dlg 2", 7.0f);
                    cube.Axes.YAxis.ScaleLabel.Font = new Font("MS Shell Dlg 2", 7.0f);


                    // setting visibility made no effect, make it indistinguable with the background instead
                    if (cubes.Count > 4)
                    {
                        cube.Axes.YAxis.ScaleLabel.Color = Color.White;
                    }


                    cube.Axes.YAxis.Ticks.Visible = true;
                    Func<int, float, string> labelFunc = (x, y) => TickPositionToDateTimeString(y);
                    cube.Axes.XAxis.Ticks.LabelTransformFunc = labelFunc;
                }

            }

            _dataTimeRange = 0.0f;
            _dataAmpRange = 0.0f;
            foreach (ILPlotCube t in cubes)
            {
                // Set amplitude view limit
                if (t.Limits.YMax > (-t.Limits.YMin))
                {
                    t.Limits.YMin = -t.Limits.YMax;
                }
                else
                {
                    t.Limits.YMax = -t.Limits.YMin;
                }

                var startTime = DateTime.Compare(stream1.GetStartDateTime(), stream2.GetStartDateTime()) < 0
                    ? stream1.GetStartDateTime()
                    : stream2.GetStartDateTime();
                var endTime = DateTime.Compare(stream1.GetEndDateTime(), stream2.GetEndDateTime()) > 0
                    ? stream1.GetEndDateTime()
                    : stream2.GetEndDateTime();

                // Set Time Increment
                _dataTimeRange = (float)(endTime - startTime).TotalSeconds / _referenceDt;


                // Set Amplitude Increment
                if (_dataAmpRange < t.Plots.GetRangeMaxValue(t.Axes.YAxis.AxisName) -
                                      t.Plots.GetRangeMinValue(t.Axes.YAxis.AxisName))
                    _dataAmpRange = t.Plots.GetRangeMaxValue(t.Axes.YAxis.AxisName) -
                                      t.Plots.GetRangeMinValue(t.Axes.YAxis.AxisName);
            }

            // default view manually
            foreach (var t in cubes)
            {
                t.Limits.XMin = 0;
                t.Limits.XMax = _dataTimeRange;
                t.Limits.YMin = _dataAmpRange / -2;
                t.Limits.YMax = _dataAmpRange / 2;
            }
        }

        /// <summary>
        /// Adds the plot to the scene. Scene must have the same number of plot cube as the number of traces in stream
        /// </summary>
        /// <param name="scene">scene to add plot into</param>
        /// <param name="stream">The stream.</param>
        private void AddPlot(ILGroup scene, ISeismicStream stream)
        {
            // access cube
            var cubes = GetPlotCubes(scene);

            for (var i = 0; i < cubes.Count; i++)
            {
                using (ILScope.Enter())
                {
                    var trace = stream.Traces[i];
                    var cube = cubes[i];

                    /*// since ILMemoryPool take ownership of the array, we give them a copy instead.
                    var traceArrCopy = new float[trace.Count];
                    Array.Copy(trace.Data, traceArrCopy, trace.Count);
                    ILArray<float> ilArray = traceArrCopy;*/

                    // since this is reduced stream, we don't need to make another copy, just leave it to ILMemoryPool
                    ILArray<float> ilArray = trace.Data;


                    // this is color coding our line plot based on the trace channel type
                    var color = Color.Black;
                    switch (trace.Header.ChannelType)
                    {
                        case ChannelType.Z:
                            color = Color.RoyalBlue;
                            break;
                        case ChannelType.N:
                            color = Color.Red;
                            break;
                        case ChannelType.E:
                            color = Color.LimeGreen;
                            break;
                    }
                    
                    // if given trace has the same delta with this viewer delta reference and the same starting time
                    // we could just add the value array without the time array since it will be automatically assigned by ILLinePlot
                    if (trace.Header.Delta.Equals(_referenceDt) && trace.Header.StartTime.Equals(_referenceStartTime))
                    {
                        Debug.WriteLine("Sampling rate and start time equal, plotting without explicit indices");
                        var plot = cube.Add(new ILLinePlot(ilArray));
                        plot.Line.Color = color;
                    }

                    // if they are not, give the time array explicitly
                    else
                    {
                        Debug.WriteLine("Sampling rate and start time are not equal, plotting with explicit indices");
                        var startPosition = (trace.Header.StartTime - _referenceStartTime).TotalSeconds/_referenceDt;
                        var steps = trace.Header.SamplingRate*_referenceDt;
                        var timeArray = new float[trace.Count];
                        for (var j = 0; j < trace.Count; j++)
                        {
                            timeArray[j]= (float) startPosition + j*steps;
                        }

                        var plot = cube.Add(new ILLinePlot(timeArray,ilArray));
                        plot.Line.Color = color;
                    }

                    cube.Axes.YAxis.Label.Text = $"{trace.Header.Station} {trace.Header.ChannelType}";
                    cube.Axes.YAxis.Label.Font = new Font("MS Shell Dlg 2", 8.0f);
                    cube.Axes.YAxis.LabelAnchor = new PointF(0.5f,0.5f);
                    cube.Axes.YAxis.LabelPosition = new Vector3(0.5f,1f,0);
                    cube.Axes.YAxis.Ticks.DefaultLabel.Font = new Font("MS Shell Dlg 2", 7.0f);
                    cube.Axes.YAxis.ScaleLabel.Font = new Font("MS Shell Dlg 2",7.0f);


                    // setting visibility made no effect, make it indistinguable with the background instead
                    if (cubes.Count > 4)
                    {
                        cube.Axes.YAxis.ScaleLabel.Color = Color.White;
                    }
                    

                    cube.Axes.YAxis.Ticks.Visible = true;
                    Func<int, float, string> labelFunc = (x, y) => TickPositionToDateTimeString(y);
                    cube.Axes.XAxis.Ticks.LabelTransformFunc = labelFunc;
                }
                
            }

            _dataTimeRange = 0.0f;
            _dataAmpRange = 0.0f;
            foreach (ILPlotCube t in cubes)
            {
                // Set amplitude view limit
                if (t.Limits.YMax > (-t.Limits.YMin))
                {
                    t.Limits.YMin = -t.Limits.YMax;
                }
                else
                {
                    t.Limits.YMax = -t.Limits.YMin;
                }

                // Set Time Increment
                _dataTimeRange =(float) (_stream.GetEndDateTime() - _stream.GetStartDateTime()).TotalSeconds/_referenceDt;


                // Set Amplitude Increment
                if (_dataAmpRange < t.Plots.GetRangeMaxValue(t.Axes.YAxis.AxisName) -
                                      t.Plots.GetRangeMinValue(t.Axes.YAxis.AxisName))
                    _dataAmpRange = t.Plots.GetRangeMaxValue(t.Axes.YAxis.AxisName) -
                                      t.Plots.GetRangeMinValue(t.Axes.YAxis.AxisName);
            }

            // default view manually
            foreach (var t in cubes)
            {
                t.Limits.XMin = 0;
                t.Limits.XMax = _dataTimeRange;
                t.Limits.YMin = _dataAmpRange / -2;
                t.Limits.YMax = _dataAmpRange / 2;
            }
        }


        /// <summary>
        /// Translate the position of ticks into equivalent datetime string based on this viewer reference start time.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>System.String.</returns>
        private string TickPositionToDateTimeString(float pos)
        {
            return _referenceStartTime.AddSeconds(pos*_referenceDt).ToString("H'h'm'm's.f's'");
        }

        /// <summary>
        /// Initializes the panel.
        /// </summary>
        private void InitializePanel()
        {
            SuspendLayout();
            _ilPanel = new ILPanel
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(_ilPanel);
            ResumeLayout();
        }


        /// <summary>
        /// Create a scene that consist of n formatted plot cube(s).
        /// </summary>
        /// <param name="n">Number of cubes.</param>
        /// <returns>ILScene.</returns>
        private ILScene CreatePlotCubes(int n)
        {
            var scene = new ILScene();
            
            // remove default powered by ilnumerics
            scene.Screen.Children.RemoveAt(0);

            // calculate the position of each cube given number of cubes
            for (var i = 0; i < n; i++)
            {
                var cube = new ILPlotCube($"cube{i}");

                var dataRectXOffset = 0.06f;
                if (i == n - 1)
                {
                    var magicConstant = 0.8f - 0.8f*0.08f/(0.92f/n + 0.08f);
                    cube.ScreenRect = new RectangleF(0, i*0.92f/n, 1, 0.92f/n + 0.08f);
                    cube.DataScreenRect = new RectangleF(dataRectXOffset, 0.1f, 1 - dataRectXOffset - 0.02f, magicConstant);
                    cube.Axes.XAxis.Ticks.DefaultLabel.Font = new Font("Ms Shell Dlg 2", 8.0f);
                    cube.Axes.XAxis.Label.Font = new Font("Ms Shell Dlg 2", 8.0f);
                    cube.Axes.XAxis.Label.Text = "Time";
                }
                else
                {
                    cube.ScreenRect = new RectangleF(0, i*0.92f/n, 1, 0.92f/n);
                    cube.DataScreenRect = new RectangleF(dataRectXOffset, 0.1f, 1 - dataRectXOffset - 0.02f, 0.8f);
                    cube.Axes.XAxis.Label.Visible = false;
                    cube.Axes.XAxis.Ticks.Visible = false;
                }

                // turn off default mouse interaction with the cube
                cube.AllowPan = false;
                cube.AllowZoom = false;
                cube.AllowRotation = false;
                cube.Axes.ZAxis.Visible = false;

                // make the label horizontal
                cube.Axes.YAxis.LabelRotation = 0;

                // prevent the axis autoscaler from kicking in so we can adress each point by its indices
                cube.Axes.XAxis.Ticks.MaxNumberDigitsShowFull = 10;

                // prevent default reset on mouse double click
                cube.MouseDoubleClick += (s, e) => e.Cancel = true;
                cube.Limits.Changed += Limits_Changed;

                scene.Add(cube);
            }

            return scene;
        }


        /// <summary>
        /// Handles the Changed event of the Limits control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ClippingChangedEventArgs"/> instance containing the event data.</param>
        private void Limits_Changed(object sender, ClippingChangedEventArgs e)
        {
            Debug.WriteLine("Limit changed......");
            // move time windows overlay if it exists
            if (_timeWindows != null)
                SetWindowOverlayPosition();
            if (_cutlineValue != null)
            {
                SetCutlineOverlayPosition(_cutlineValue[0],Cutline.StartLine);
                SetCutlineOverlayPosition(_cutlineValue[1], Cutline.EndLine);
            }
                
        }

        /// <summary>
        /// Handles the Resize event of the splitContainerControl1 control.
        /// Keep the splitter position at the center on resize 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void splitContainerControl1_Resize(object sender, EventArgs e)
        {
            var splitPanel = sender as SplitContainerControl;
            if (splitPanel != null) splitPanel.SplitterPosition = splitPanel.Size.Width/2;
        }

        /// <summary>
        /// Handles the scroll event of the scrollBar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Debug.WriteLine(hScrollBar1.Value);
            var frameSize = _dataTimeRange - _dataTimeRange*zoomTrackBarControl2.Value/1000;
            Pan(hScrollBar1.Value, frameSize);
            _ilPanel.Refresh();
        }

        private void zoomTrackBarControl1_ValueChanged(object sender, EventArgs e)
        {
            ZoomAmp(zoomTrackBarControl1.Value);
            _ilPanel.Refresh();
        }

        /// <summary>
        /// Handles the zoommingTrackBarControl for zooming waveform time/x axis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomTrackBarControl2_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(zoomTrackBarControl2.Value);
            hScrollBar1.LargeChange = 1000-zoomTrackBarControl2.Value;
            ZoomTime(zoomTrackBarControl2.Value);
            _ilPanel.Refresh();
        }


        /// <summary>
        /// Methods for zoom time/x axis 
        /// </summary>
        /// <param name="fractValue"></param>
        private void ZoomTime(int fractValue)
        {
            var cubes = GetPlotCubes();
            foreach (var t in cubes)
            {
                var newLimitXMax = t.Limits.XMin + _dataTimeRange - _dataTimeRange*fractValue/1000;
                if (newLimitXMax > _dataTimeRange)
                {
                    t.Limits.XMin = t.Limits.XMax - _dataTimeRange + _dataTimeRange * fractValue / 1000;
                }
                else
                {
                    t.Limits.XMax = newLimitXMax;
                }
                
            }
        }

        /// <summary>
        /// Methods for panning the cube
        /// </summary>
        /// <param name="position"></param>
        /// <param name="frameSize"></param>
        private void Pan(int position, float frameSize)
        {
            var cubes = GetPlotCubes();
            foreach (var t in cubes)
            {
                t.Limits.XMin = _dataTimeRange/1000*position;
                t.Limits.XMax = t.Limits.XMin + frameSize;
            }
        }

        /// <summary>
        /// Methods for zooming the cube
        /// </summary>
        /// <param name="multiplicator"></param>
        private void ZoomAmp(int multiplicator)
        {
            var cubes = GetPlotCubes();
            foreach (var t in cubes)
            {
                t.Limits.YMin = -0.5f*_dataAmpRange/(multiplicator + 1);
                t.Limits.YMax = 0.5f*_dataAmpRange/(multiplicator + 1);
            }
            
        }

        /// <summary>
        /// Turn Pointer Location to X axis value
        /// </summary>
        /// <param name="pointerLoc">Pointer Location</param>
        /// <returns>X axis value</returns>
        float GetxAxisPosition(ILMouseEventArgs pointerLoc)
        {
            var cube = GetPlotCubes();
            var curXMax = cube[0].Limits.XMax;
            var curXMin = cube[0].Limits.XMin;
            var pointerLocation = (pointerLoc.LocationF.X - 0.06f) / 0.92f;
            var xAxisPosition = pointerLocation * (curXMax - curXMin) + curXMin;
            return xAxisPosition;
        }

        private void barCheckItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_delWindowActive == false) return;
            Debug.WriteLine(_ilPanel.Rectangle.X);
            
        }

        private void InitiateDeleteWindowsTool()
        {
            _ilPanel.Scene.MouseClick += (s, arg) =>
            {
                if (_delWindowActive == false && _addWindowActive == false) return;
                var xAxisPosition = GetxAxisPosition(arg);
                if (arg.Button == MouseButtons.Left)
                {
                    if (_delWindowActive)
                        RemoveTimeWindowAt(xAxisPosition);

                    if (_addWindowActive)
                        AddTimeWindowAt(xAxisPosition);
                }
                
            };
        }

        private void InitiateCutlineTool()
        {
            _ilPanel.Scene.MouseMove += (s, e) =>
            {
                if (_cutlineActive)
                {
                    if(GetxAxisPosition(e)>=0 && GetxAxisPosition(e)<=_dataTimeRange)
                        SetCutlineOverlayPosition(GetxAxisPosition(e), _selectedCutline);
                    else if(GetxAxisPosition(e)<0)
                        SetCutlineOverlayPosition(0, _selectedCutline);
                    else if (GetxAxisPosition(e) > _dataTimeRange)
                        SetCutlineOverlayPosition(_dataTimeRange, _selectedCutline);
                    Debug.WriteLine(GetxAxisPosition(e));
                }
                
            };

            _ilPanel.Scene.MouseDown += (s, e) =>
            {
                if (Math.Abs(GetxAxisPosition(e) - _cutlineValue[0]) < 1000)
                {
                    _cutlineActive = true;
                    _selectedCutline = Cutline.StartLine;
                }
                else if (Math.Abs(GetxAxisPosition(e) - _cutlineValue[1]) < 1000)
                {
                    _cutlineActive = true;
                    _selectedCutline = Cutline.EndLine;
                }
                     
            };

            _ilPanel.Scene.MouseUp += (s, e) =>
            {
                _cutlineActive = false;
                OnCutMarkerDrawn?.Invoke(GetCutlineValue()[0], GetCutlineValue()[1]);
            };

        }
    }
}