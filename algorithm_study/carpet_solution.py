def solution(brown, red):
    root = int(((brown + 4) ** 2 - 16*(brown + red)) ** 0.5)
    horizontal = int(((brown + 4) + root) / 4)
    vertical = int((brown + red) / horizontal)
    return [horizontal, vertical]