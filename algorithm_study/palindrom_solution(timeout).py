def solution(s):
    s = list(s)
    plus_length = len(s)
    while plus_length > 1:     
        for i in range(len(s)):
            if palindrome(s[i:i+plus_length]) and i+plus_length <= len(s):
                return plus_length
        plus_length -= 1
    return plus_length

def palindrome(s):
    return s == s[::-1]