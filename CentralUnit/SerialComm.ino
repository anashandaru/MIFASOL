// Command list
enum
{
    kCommTest, // 0. send command to test the communication between central unit and computer
    kCommReport, // 1. receive command report from the central unit
    kChannelSearch, // 2. send command to search all available channel
    kChannelFounded, // 3. receive information about all availabel channel
    kSetNumOfSample, // 4. send command to set recording time
    kSetSamplingRate, // 5. send command to set sampling rate
    kSetGain, // 6. send command to set gain
    kClearMemory, // 7. send command to clear flash memory
    kSetTriggerSensitivity, // 8. send command to trigger sensitivity
    kArmTrigger, // 9. send command to arm trigger
    kTriggered, // 10. received if the instrument has been triggered
    kRequestData, // 11. send command to receive data
    kReceiveData, // 12. receive data from central unit
};

void attachCommandCallBacks()
{
	cmdMessenger.attach(OnUnknownCommand);
	cmdMessenger.attach(kCommTest, OnCommTest);
	cmdMessenger.attach(kChannelSearch, OnChannelSearch);
	cmdMessenger.attach(kSetNumOfSample, OnSetNumOfSample);
	cmdMessenger.attach(kSetSamplingRate, OnSetSamplingRate);
	cmdMessenger.attach(kSetGain, OnSetGain);
  cmdMessenger.attach(kClearMemory, OnClearMemory);
  cmdMessenger.attach(kSetTriggerSensitivity, OnSetTriggerSensitivity);
	cmdMessenger.attach(kArmTrigger, OnArmTrigger);
	cmdMessenger.attach(kRequestData, OnRequestData);
}

void OnUnknownCommand()
{
  cmdMessenger.sendCmd(0,"Command without attached callback");
}

void OnCommTest()
{}

void OnChannelSearch()
{
  // Disable new lines, this saves another 2 chars per command
  cmdMessenger.printLfCr(false); 
	for (byte i = 8; i < 72; i++)// Constrained to 32-8 iteration from 120-8
	{
		
		// test every address and send the address over serial if the it respond
		if(testAddress((uint8_t) i))
		{
			cmdMessenger.sendCmdStart(kChannelFounded);
      cmdMessenger.sendCmdBinArg<bool>(false);
			cmdMessenger.sendCmdBinArg<uint16_t>((uint16_t) i);
			cmdMessenger.sendCmdEnd();
		}
 
	}
  cmdMessenger.sendCmdStart(kChannelFounded);
  cmdMessenger.sendCmdBinArg<bool>(true);
  cmdMessenger.sendCmdEnd();
  
  // Re-enable new lines, for human readability
  cmdMessenger.printLfCr(true);
}

void OnSetNumOfSample()
{
	ndata = cmdMessenger.readBinArg<uint16_t>();
}

void OnSetSamplingRate()
{}

void OnSetGain()
{
  uint8_t address = (uint8_t) cmdMessenger.readBinArg<uint16_t>();
  int wiper = cmdMessenger.readBinArg<int16_t>();
  SetGain(address, wiper);
}

void OnClearMemory()
{
  clearMemory();
}

void OnSetTriggerSensitivity()
{
  triggerThreshold = (int) cmdMessenger.readBinArg<uint16_t>();
}

void OnArmTrigger()
{
  WaitingForTrigger();
  //digitalWrite(13, HIGH);
  measureSimul(); 
}

void OnRequestData()
{
  digitalWrite(13, LOW);
	for (int i = 8; i < 72; ++i)
	{
		if(testAddress((uint8_t) i))
		{
			requestDataFrom((byte) i);
		}
	}
  SendDataTail();
}

void SendDataPacket(byte slaveAddress ,long packet[8])
{
	// Disable new lines, this saves another 2 chars per command
    cmdMessenger.printLfCr(false);
    
    cmdMessenger.sendCmdStart(kReceiveData);
    cmdMessenger.sendCmdBinArg<uint16_t>((uint16_t) slaveAddress);
    
    for (int i = 0; i < 8; ++i)
    {
    	cmdMessenger.sendCmdBinArg<int32_t>((int32_t) packet[i]);
    }
    cmdMessenger.sendCmdEnd();

    // Re-enable new lines, for human readability
    cmdMessenger.printLfCr(true); 
}

void SendDataTail()
{
  // Disable new lines, this saves another 2 chars per command
    cmdMessenger.printLfCr(false);
    
    cmdMessenger.sendCmdStart(kReceiveData);
    cmdMessenger.sendCmdBinArg<uint16_t>((uint16_t) 0);
    
    for (int i = 0; i < 8; ++i)
    {
      cmdMessenger.sendCmdBinArg<int32_t>((int32_t) 0);
    }
    cmdMessenger.sendCmdEnd();

    // Re-enable new lines, for human readability
    cmdMessenger.printLfCr(true); 
}

void WaitingForTrigger()
{
  buzzOn();
  while(true)
  {
    int16_t triggerAdc = ads.readADC_Differential_0_1();
    if(abs(triggerAdc) > triggerThreshold) break;
  }
  buzzOff();

  cmdMessenger.printLfCr(false);
  cmdMessenger.sendCmdStart(kTriggered);
  cmdMessenger.sendCmdEnd();
  cmdMessenger.printLfCr(true);
}


