import heapq

def solution(scoville, K):
    heapq.heapify(scoville)
    answer = 0
    while len(scoville) > 1:
        if scoville[0] >= K:
            return answer
        else:
            answer += 1
            first_sco = heapq.heappop(scoville)
            second_sco = heapq.heappop(scoville)
            sum_sco = first_sco + (second_sco * 2)
            heapq.heappush(scoville, sum_sco)
    if scoville[0] < K:
        return -1

    return answer