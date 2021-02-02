from queue import deque

# 유효한 스킬트리인지 검증
def is_vaild(skill, skill_tree):
    skill = deque(skill)
    skill_tree = list(skill_tree)

    if not skill:
        return True

    if skill[0] in skill_tree:
        s = skill.popleft()
        count = 0
        prefix = skill_tree[:skill_tree.index(s)+1]
        suffix = skill_tree[skill_tree.index(s)+1:]
        for sk in skill:
            if sk in prefix:
                count += 1
        if count == 0:
            return is_vaild(skill, suffix)
        elif count != 0:
            return False

    else:
        for sk in skill:
            if sk in skill_tree:
                return False
        return True

def solution(skill, skill_trees):
    ret = 0

    for st in skill_trees:
        if is_vaild(skill, st):
            ret += 1
            
    return ret