
enum
{
  kRequestData,
  kReceiveData,
};

void attachCommandCallbacks()
{
  cmdMessenger.attach(OnUnknownCommand);
  cmdMessenger.attach(kRequestData, OnRequestData);
}

void OnUnknownCommand()
{
  cmdMessenger.sendCmd(0,"Command without attached callback");
}

void OnRequestData()
{
	uint16_t dataLength = cmdMessenger.readBinArg<uint16_t>();
	
	// Disable new lines, this saves another 2 chars per command
    cmdMessenger.printLfCr(false); 
	for (int i = 0; i < dataLength/8; ++i)
	{
		cmdMessenger.sendCmdStart(kReceiveData);
		cmdMessenger.sendCmdBinArg<uint16_t>((uint16_t)i);
		for (int j = 0; j < 8; ++j)
		{
			cmdMessenger.sendCmdBinArg<int32_t>((int32_t)(i*8+j));
		}
		cmdMessenger.sendCmdEnd();
	}
	// Re-enable new lines, for human readability
    cmdMessenger.printLfCr(true); 
}