# CryptographyEncryption-C#
Implementation of a class in C # to use cryptographic method


# Some essential concepts concerning Cryptography

- Cipher: The procedure that will render a message unintelligible to the recipient. It's also used to recreate the original message, depending on the encryption mechanism used.

- Plaintext: The message or information that is being encrypted.

- Ciphertext: The message or information that is created after the cipher has been used.


linear algebra based cipher, the Hill cipher, which uses a matrix as a cipher to encode a message, and it's extremely difficult to break when a large matrix is used. The receiver of the message decodes it using the inverse of the matrix. This first matrix is called the encoding matrix and its inverse is called the decoding matrix.


# How does this method work?

Transform the text to a sequence of numbers by giving each character a unique numerical value, then split the numbers to form a matrix by grouping the numbers into columns according to the order of the matrix A (the amount of elements in each column must be equal to the order of the matrix). Let's call this matrix B (the plain matrix). Multiply the matrix A by the matrix B:

C = A•B
The matrix C is the cipher matrix. To decrypt the message, just multiply Inv(A)•C, where Inv(A) is the inverse matrix of A.

Note that:

Inv(A)•C = Inv(A)•A•B = I•B = B
The original plaintext can be found again by taking the resulting matrix and splitting it back up into its separate vectors, making them a sequence, and then converting the numbers back into their letter forms.


# How to use

Change the text given in exmapleClass and the run it.

