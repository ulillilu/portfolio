from collections import deque
import math

def solution(progresses, speeds):
    answer = []
    cache = 0
    ret = deque([math.ceil((100-progresse)/speed) for progresse, speed in list(zip(progresses, speeds))])

    for i in range(len(ret)):
        if ret[cache] < ret[i]:
            answer.append(i-cache)
            cache = i
        if i == len(ret) - 1:
            answer.append(i-cache+1)

    return answer