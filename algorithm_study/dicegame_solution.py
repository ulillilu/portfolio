from itertools import product

def solution(monster, S1, S2, S3):
    monster = set(monster)
    dice = [list(range(1, S1+1)), list(range(1, S2+1)), list(range(1, S3+1))]
    number_of_cases = 0
    product_dice = list(product(*dice))
    
    for pd in product_dice:
        dice_sum = sum(pd) + 1
        if dice_sum in monster:
            number_of_cases += 1
            
    return int((1 - (number_of_cases / len(product_dice))) * 1000)
