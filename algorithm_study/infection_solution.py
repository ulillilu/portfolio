from collections import deque

def bfs(starts, m, n, infected):
    q = deque()
    for start in starts:
        q.append(start)

    next_q = deque()
    direction = [(0, 1), (1, 0), (0, -1), (-1, 0)]
    day = 0

    while q:
        y, x = q.popleft()
        for dy, dx in direction:
            ny = y + dy
            nx = x + dx
            if 0 <= ny < m and 0 <= nx < n and not infected[ny][nx]:
                infected[ny][nx] = True
                next_q.append((ny, nx))
                day = 1
    
    return next_q, day

# 감염되지 않은 사람 : False, 감염된 사람 : True, 백신을 맞은 사람 -1
def solution(m, n, infests, vaccinateds):
    answer = 0
    VACCINATED = -1
    # m*n 크기의 False행렬 생성
    infected = [[False for _ in range(n)] for _ in range(m)]
    # 백신을 맞은 사람 표시
    for y, x in vaccinateds:
        infected[y-1][x-1] = VACCINATED  
        
    starts = [(y-1, x-1) for y, x in infests]
    for y, x in starts:
        infected[y][x] = True

    while starts:
        starts, days = bfs(starts, m, n, infected)
        answer += days

    for y in range(m):
        for x in range(n):
            if infected[y][x] == False:        
                return -1
    return answer