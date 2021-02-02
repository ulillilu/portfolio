def solution(s):
    stack = []
    for bracket in s:
        if bracket == "(":
            stack.append(bracket)
        else:
            if stack:
                stack.pop()
            else:
                return False
    if not stack:
        return True
    return False