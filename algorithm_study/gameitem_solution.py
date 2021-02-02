import heapq

def solution(healths, items):
    healths.sort()
    # 깎는 체력이 작은 순으로 정렬
    # enumerate : 인덱스 번호와 원소를 tuple 형태로 반환
    items = [[item[1], item[0], idx] for idx, item in enumerate(items, 1)]
    items.sort()
    
    DEBUFF, BUFF, ITEM_ID = 0, 1, 2

    cache = []
    heapq.heapify(cache)
    answer = []
    item_idx = 0

    for health in healths:
        while item_idx < len(items):
            item = items[item_idx]
            if health - item[DEBUFF] < 100:
                break
            # 올려주는 공격력(역수)과 아이템 번호 저장
            heapq.heappush(cache, (-item[BUFF], item[ITEM_ID]))
            item_idx += 1
        # 해당 hp에서 가장 많이 공격력을 올려주는 아이템 번호 answer에 저장
        if cache != []:
            _, index = heapq.heappop(cache)
            answer.append(index)

    return sorted(answer)