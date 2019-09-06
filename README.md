# CryptographyEncryption-C-
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


# Example

We shall use the following message
The password is: NCS-2014
First, we must assign each letter a numeric equivalent. As state above, we'll use the Unicode number for each character. For the message to encrypt, we get the following sequence of numbers:
84 104 101 32 112 97 115 115 119 111 114 100 32 105 115 58 32 78 67 83 45 50 48 49 52

Coding matrix

We choose the following 4x4 invertible matrix A:
    ┌               ┐
    │  1  -1  -1  1 │
    │  2  -3  -5  4 │
A = │ -2  -1  -2  2 │
    │  3  -3  -1  2 │
    └               ┘

Encrypting the Message

We convert the sequence of numbers related to plaintext into a matrix, splitting it into column vectors of 4 elements (the order of the encoding matrix). We fill out the last column with zeros as necessary to complete the 4 elements.
    ┌                                ┐
    │  84  112  119   32  32  45  52 │
    │ 104   97  111  105  78  50   0 │
B = │ 101  115  114  115  67  48   0 │
    │  32  115  100   58  83  49   0 │
    └                                ┘
We now encode the message by multiplying the encoding matrix A by the above matrix B. The result is the cipher matrix C:
          ┌                                          ┐
          │  -89    15    -6  -130   -30    -4    52 │
          │ -521  -182  -265  -594  -173  -104   104 │
C = A•B = │ -410  -321  -377  -283  -110  -138  -104 │
          │  -97   160   110  -218   -39    35   156 │
          └                                          ┘
The columns of this matrix give the encoded message. The message could be transmitted in the following linear form:
-89 -521 -410 -97 15 -182 -321 160 -6 -265 -377 110 -130 -594 -283 -218 -30 -173 -110 -39 -4 -104 -138 35 52 104 -104 156

Decrypting the message

To decode the message, write the sequence of numbers you received as a matrix, by splitting the numbers into column vectors of 4 elements. The resulting matrix from this process will be equal to the cipher matrix C. You must know the inverse of the encoding matrix:
         ┌               ┐
         │  6  -1  0  -1 │
         │ 22  -4  1  -4 │
Inv(A) = │ 14  -3  1  -2 │
         │ 31  -6  2  -5 │
         └               ┘
Multiply that matrix (decoding matrix) by the cipher matrix C. Form back the resulting matrix (it'll be equal to matrix B) into a continuous sequence of numbers and map the numbers to their corresponding characters, to get the original message.
