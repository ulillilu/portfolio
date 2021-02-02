def solution(s):
    stack = []
    
    for elem in s:
        # stack의 맨 뒷글자가 현재 비교하는 글자보다 앞에 오는 글자인경우 stack에서 제외
        while len(stack) > 0 and stack[-1] < elem:
            stack.pop()
        stack.append(elem)
        
    return "".join(stack)