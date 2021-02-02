from itertools import combinations

def solution(n):
    answer = 0
    primes = combinations(sieve(n), 3)
    for prime in primes:
        if sum(prime) == n:
            answer += 1
    return answer

    
def sieve(n):
    is_prime = [True] * (n+1)
    is_prime[0] = False
    is_prime[1] = False

    for candidate in range(2, n+1):
        if not is_prime[candidate]:
                continue
        for multiple in range(candidate*candidate, n+1, candidate):
                is_prime[multiple] = False

    return [idx for idx, value in enumerate(is_prime) if value]