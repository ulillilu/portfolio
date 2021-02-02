def solution(s):
    stack = []
    pair = {"(":")", "[":"]", "{":"}"}

    for bracket in s:
        if bracket in pair:
            stack.append(bracket)

        else:
            if not stack:
                return False
            if bracket == pair[stack[-1]]:
                stack.pop()
            else:
                return False

    return True if not stack else False