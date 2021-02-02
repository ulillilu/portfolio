def solution(dirs):
    start = (0, 0)
    ret = []
    DELTAS = {'U': (0, 1), 'D': (0, -1), 'L': (-1, 0), 'R': (1, 0)}
    for direction in dirs:
        x, y = start
        dx, dy = DELTAS[direction]
        if -5 <= x+dx <= 5 and -5 <= y+dy <= 5:
            goal = (x+dx, y+dy)
            ret.append(tuple(sorted([start, goal])))
            start = goal

    return len(set(ret))