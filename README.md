# FreeLogIn - BLE



FreeLogIn is an OpenSoftware develoed with C#, C++ and Batch Script Language. FreeLogIn allows users to auto log off and auto login to windows. So, Users no longer have to type password or security code. It makes your life much easier just like using Macbook and Iphone.


# Important Feature

  - It encrypts windows password and Mac Address of Bluetooth device, which is connnected to.
  - It has simple batch file such as "ServiceRun", "ServiceStop", and "ServiceDelete" for users to use conveniently to add FreeLogIn windows service or not.
  - It automatically logs off when the device is not near laptop for 15 seconds.


You can also:
  - Change our encryption method to secure the password and Mac Address. It is very simple to edit.
  - We do not restrict devices, not like "Apple", which means it works with any device that has Bluetooth function in it.



> We are not like fruit company which restrict useability
> and user's freedom. This was developed by 3 students
> in KNU. Who are into using Opensource and fascinated about
> Information Security. If you any questions about us please
> email us suing via email at the bottom

### Tech

FreeLogIn uses a number of open source projects to work properly:

* [XORENCRYPTION] - Password and Mac Address string encryption!
* [Windows Credential Provider] - Whole thing
* [Create Processor User] - Used to lock Windows
* [32feet.NET] - Bluetooth Service synchronization and Searching (Request C#)

### Installation

1. Please pair your device with your laptop using Bluetooth
2. Run listbluetoothdevice.exe and type password and choose the device you want to use as auto login device
3. Run ServiceRunStart batch file
4. Move BluetoothAUTOLogin.dll to system32
5. Register register.reg in BluetoothAutoLogin\BluetoothCredentialProvider\cpp directory
6. and now you are done try out!



And run
#### Building for source
Build with option release and 64x
very simple to use

### Todos

 - Add Better Encryption method
 - Better UI Environment

License
----

MIT
MIT License

Copyright (c) [2017] [HONG JAE KIM, DONG HO KIM, YOUNG JIN KIM ]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

**Free Software, Hell Yeah!**




   [Windows Credential Provider]: <https://github.com/Microsoft/Windows-classic-samples/tree/master/Samples/CredentialProvider>
   [Create Processor User]: <https://github.com/murrayju/CreateProcessAsUser>
   [XORENCRYPTION]: https://github.com/KyleBanks/XOREncryption
   [32feet.NET]: <https://github.com/inthehand/32feet>

   [PlDb]: <https://github.com/joemccann/dillinger/tree/master/plugins/dropbox/README.md>
   [PlGh]: <https://github.com/joemccann/dillinger/tree/master/plugins/github/README.md>
   [PlGd]: <https://github.com/joemccann/dillinger/tree/master/plugins/googledrive/README.md>
   [PlOd]: <https://github.com/joemccann/dillinger/tree/master/plugins/onedrive/README.md>
   [PlMe]: <https://github.com/joemccann/dillinger/tree/master/plugins/medium/README.md>
   [PlGa]: <https://github.com/RahulHP/dillinger/blob/master/plugins/googleanalytics/README.md>
   
   
