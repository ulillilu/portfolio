def bfs(sign, signs, n):
    cache = [sign]
    bus_stop = [0 for i in range(n)]

    while cache:
        current_sign = cache.pop()
        for i in range(len(current_sign)):
            if current_sign[i] == 1 and bus_stop[i] == 0:
                bus_stop[i] = 1
                cache.append(signs[i])

    return bus_stop

def solution(n, signs):
    sign = [0, 1, 0]
    ret = []

    for sign in signs:
        ret.append(bfs(sign, signs, n))

    return ret