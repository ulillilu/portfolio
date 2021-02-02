def solution(l, v):
    v.sort()
    distance = []
    ret = [v[0], l - v[-1]]
    if len(v) == 1:
        return max(ret)
    
    for i in range(len(v) - 1):
        distance.append(v[i+1] - v[i])
    ret.append(int((max(distance) + 1) / 2))

    return max(ret)