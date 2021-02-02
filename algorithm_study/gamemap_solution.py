from collections import deque

# 루트가 갈라질 수 있으므로 해당 루트의 move를 가지고 이동한다.
def bfs(start, maps):
    q = deque()
    q.append(start)
    direction = [(0, 1), (1, 0), (0, -1), (-1, 0)]
    
    while q:
        y, x, move = q.popleft()
        maps[y][x] = 0
        for dy, dx in direction:
            ny = y + dy
            nx = x + dx
            # 가장 먼저 도착한 경우가 최단 거리
            # 현재 위치에서 다음위치로 이동했을 때 목적지이면, 지금까지의 move+1 반환
            if ny == len(maps)-1 and nx == len(maps[0])-1:
                return move+1
            
            if 0 <= ny < len(maps) and 0 <= nx < len(maps[0]) and maps[ny][nx] == 1:
                maps[ny][nx] = 0
                q.append((ny, nx, move+1))
    return -1

def solution(maps):
    return bfs((0, 0, 1), maps)