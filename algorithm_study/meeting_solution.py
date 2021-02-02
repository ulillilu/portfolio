def solution(arr):
    # 빨리 끝나는 순서대로 정렬, 같은 시간에 끝나는 회의는 먼저 시작하는 것을 우선
    arr = sorted(arr, key = lambda x:(x[1], x[0]))
    # earliest : 다음 회의가 시작할 수 있는 가장 빠른 시간
    earliest = 0
    selected = 0
    for meeting_begin, meeting_end in arr:
        if earliest <= meeting_begin:
            # 다음 회의 시작 시간을 이전 미팅이 끝난 시간으로 갱신
            earliest = meeting_end
            selected += 1
    return selected
