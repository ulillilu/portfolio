import sys
sys.setrecursionlimit(100000)

MOD = 1_000_000_007

cache = [None for i in range(60001)]

def solution(width):
    if width <= 1:
        return 1
    if cache[width] is not None:
        return cache[width]
    cache[width] = (solution(width-2) + solution(width-1)) % MOD
    return cache[width]