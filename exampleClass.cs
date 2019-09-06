public void TestHillCipher()
{
    var encodingMatrix = new[,] { { 1, -1, -1, 1 }, { 2, -3, -5, 4 }, { -2, -1, -2, 2 }, { 3, -3, -1, 2 } };
    var decodingMatrix = new[,] { { 6, -1, 0, -1 }, { 22, -4, 1, -4 }, { 14, -3, 1, -2 }, { 31, -6, 2, -5 } };
    var hillCipher = new HillCipher(encodingMatrix, decodingMatrix, true);
    const string PlainText = "Lorem ipsum dolor sit amet, quis phasellus diam, nunc duis. Odio magna amet wisi duis sit iaculis, ac sodales dolores pellentesque orci vestibulum, nulla et quis id iaculis lorem, vestibulum massa sociis in, mauris ac vestibulum sociis hendrerit eros a. Mauris varius molestie in sem mi, id mattis purus, dolor vitae euismod nisl mauris nulla varius, ut libero sem, quam velit vestibulum quam.";
    var cipherText = hillCipher.EncryptText(PlainText);
    Console.WriteLine(cipherText);
    var decryptedText = hillCipher.DecryptText(cipherText);
    Console.WriteLine(decryptedText);
}
