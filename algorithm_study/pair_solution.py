def solution(s):
    match = []
    for letter in s:
        match.append(letter)
        while len(match) >= 2 and match[-1] == match[-2]:
            match.pop()
            match.pop()
    if not match:
        return 1
    else:
        return 0