#include <string>

using namespace std;

string encryptDecrypt(string toEncrypt) {
	char key[6] = { 'E', 'X', 'I', 'T', 'H', 'O' }; //Any chars will work, in an array of any size
	string output = toEncrypt;

	for (int i = 0; i < toEncrypt.size(); i++)
		output[i] = toEncrypt[i] ^ key[i % (sizeof(key) / sizeof(char))];

	return output;
}
