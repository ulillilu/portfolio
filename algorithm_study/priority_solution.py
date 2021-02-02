from queue import deque
import heapq

def solution(reqs):
    # 3초 마다 요청할 목록
    reqs = [[-order[0], order[1], idx] for idx, order in enumerate(reqs, 1)]
    will_reqs = deque(reqs)
    # 요청 대기 목록
    waits = []
    # 현재 요청의 남은 처리 시간
    now_work = 0

    WORKTIME, INDEX = 1, 2

    sec = 0
    answer = []

    while will_reqs or waits:
        # 3초 마다 요청을 대기열에 추가
        if sec % 3 == 0 and will_reqs:
            heapq.heappush(waits, will_reqs.popleft())
        # 현재 요청이 비어있으면 대기중인 요청 중 가장 급한 요청을 처리
        if now_work == 0 and waits:
            wait = heapq.heappop(waits)
            now_work = wait[WORKTIME]
            answer.append(wait[INDEX])
        # 처리해야할 요청이 존재한다면 작업
        if now_work != 0:
            now_work -= 1

        sec += 1
        
    return answer