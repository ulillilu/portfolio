def solution(d, budget):
    d.sort()
    total = 0
    for idx, value in enumerate(d):
        total += value
        if total > budget:
            return idx
    return len(d)