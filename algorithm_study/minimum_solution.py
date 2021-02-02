def solution(A,B):
    A.sort()
    B.sort(reverse=True)
    ret = 0
    for a, b in zip(A, B):
        ret += a * b
    return ret