# Написать программу на любом языке программирования, реализующую шифрование и расшифровывание RSA. Выполнить проверку.


# Вспомогательная функция разделения строки на символы
def split(string):
    return [char for char in string]

# Вспомогательная функция проверки двух чисел на взаимную простоту
def is_prime( n: int, number: int):
    while(n and number):
        if(n>number):
            n %= number
        else:
            number %= n
    return (n+number == 1)
        
# Функция получения открытого и закрытого ключа        
def get_key(p:int, q:int):
    n=p*q
    fi=(p-1)*(q-1)
    public_key=[]
    private_key=[]
    for e in range(int(n/3), n):
        if(is_prime(e, n)):
            public_key.append(e)
            public_key.append(n)
            break
    for k in range(1, fi):
        d=(k*fi+1)/public_key[0]
        if(d.is_integer()):
            private_key.append(int(d))
            private_key.append(n)
            break

    return public_key, private_key

# Функция кодирования текста RSA
def encryption_rsa(text, public_key):
    encoded_list=[]
    for T in text:
        encoded_list.append(chr(ord(T)**public_key[0] % public_key[1]))
    encoded_text=''.join(encoded_list)
    return encoded_text

# Функция декодирования текста RSA
def decoding_rsa(encoded_text, private_key):
    decoding_list=[]
    for C in encoded_text:
        decoding_list.append(chr(ord(C)**private_key[0] % private_key[1]))
    decoding_text=''.join(decoding_list)
    return decoding_text




if __name__ == "__main__":
    p=61
    q=101
    

    text = 'С учётом сложившейся международной обстановки, новая модель организационной деятельности предоставляет широкие'

    public_key, private_key=get_key(p,q)
    
    encoded_text=encryption_rsa(text, public_key)
    decoding_text=decoding_rsa(encoded_text, private_key)
    
    print(encoded_text) # вывод закодированного текста

    print(decoding_text) # вывод раскодированного текста
