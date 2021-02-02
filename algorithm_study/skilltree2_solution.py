def solution(skills_orders, skill_tree):
    order = []
    skill_order_table = {}
    
    for idx, sk_orders in enumerate(skills_orders, 1):
        skill_order_table[sk_orders] = idx
        
    for sk_tree in skill_tree:
        idx = skill_order_table.get(sk_tree, 0)
        if idx != 0:
            order.append(idx)
    # 정렬 및 등차수열 확인
    is_correct = (sorted(order) == order) and len(order) * (len(order) + 1) // 2 == sum(order)

    if is_correct:
        return True
        
    return False