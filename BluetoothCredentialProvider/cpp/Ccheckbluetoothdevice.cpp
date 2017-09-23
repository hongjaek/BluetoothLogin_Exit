#include <stdlib.h>
#include <stdio.h>
#include <Winsock2.h>
#include <Ws2bth.h>
#include <BluetoothAPIs.h>
#include <iostream>
#include <fstream>
#include <string>
#include"Ccheckbluetoothdevice.h"

#pragma comment(lib, "ws2_32.lib")
#pragma comment(lib, "irprops.lib")

SOCKADDR_BTH sockAddr;
SOCKET btSocket;
int error;

using namespace std;


bool Check_BluetoothDevice(void)
{
	WORD wVersionRequested;
	WSADATA wsaData;
	int err;
	ifstream ifil;
	TIMEVAL Timeout;

	Timeout.tv_sec = 2;
	Timeout.tv_usec = 0;

	wVersionRequested = MAKEWORD(2, 2);

	err = WSAStartup(wVersionRequested, &wsaData);
	if (err != 0) {
		printf("WSAStartup failed with error: %d\n", err);
		WSACleanup();
		return FALSE;
	}

	btSocket = socket(AF_BTH, SOCK_STREAM, BTHPROTO_RFCOMM);
	memset(&sockAddr, 0, sizeof(sockAddr));
	sockAddr.addressFamily = AF_BTH;
	sockAddr.serviceClassId = RFCOMM_PROTOCOL_UUID;
	sockAddr.port = BT_PORT_ANY;
	string temp;

	ifil.open("C:\\BluetoothAutoLogin\\confirm.txt");
	std::getline(ifil, temp);
	std::getline(ifil, temp);
	
	sockAddr.btAddr = stoull(encryptDecrypt(temp), NULL, 0);
	ifil.close();

	unsigned long iMode = 1;
	int iResult = ioctlsocket(btSocket, FIONBIO, &iMode);

	error = connect(btSocket, (SOCKADDR*)&sockAddr, sizeof(sockAddr));

	if (error == false)
	{
		closesocket(btSocket);
		WSACleanup();
		return FALSE;
	}

	iMode = 0;
	iResult = ioctlsocket(btSocket, FIONBIO, &iMode);

	fd_set Write, Err;
	FD_ZERO(&Write);
	FD_ZERO(&Err);
	FD_SET(btSocket, &Write);
	FD_SET(btSocket, &Err);

	// check if the socket is ready
	select(0, NULL, &Write, &Err, &Timeout);
	if (FD_ISSET(btSocket, &Write))
	{
		closesocket(btSocket);
		WSACleanup();
		return true;
	}

	closesocket(btSocket);
	WSACleanup();
	return false;
}