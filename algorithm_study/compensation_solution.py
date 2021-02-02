import heapq

def solution(no, works):
    works = [-work for work in works]
    heapq.heapify(works)

    for _ in range(no):
        if works[0] == 0:
            return 0
        work = heapq.heappop(works)
        work += 1
        heapq.heappush(works, work)

    return sum([work ** 2 for work in works])