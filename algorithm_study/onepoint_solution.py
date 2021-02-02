import collections

def solution(v):
    answer = []
    for i in range(2):
        pos = [vertex[i] for vertex in v]
        counter = dict(collections.Counter(pos))
        answer += [vertex for vertex, val in counter.items() if val == 1]

    return answer