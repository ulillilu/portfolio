def solution(N, number):
    cache = []
    # 8회 반복
    for i in range(1, 9):
        # num_set에 N을 i번 붙여 만든 수 추가
        num_set = {int(str(N) * i)}
        # i-1회 반복
        for j in range(i-1):
            # ex) N을 4개를 사용해서 나타낼 수 있는 숫자의 집합을 N(4)라하면
            # N(4)는 N(3)과 N(1), N(2)와 N(2)의 조합으로 표현한다.
            for x in cache[j]:
                for y in cache[-j - 1]:
                    num_set.add(x + y)
                    num_set.add(x - y)
                    num_set.add(x * y)
                    if y != 0:
                        num_set.add(x // y)
        if number in num_set:
            return i
        cache.append(num_set)
    return -1