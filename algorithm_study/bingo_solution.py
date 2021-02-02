def solution(board, nums):
    bingo = 0
    num = set(nums)
    board_column = list(map(list, zip(*board)))
    # 가로줄 순회
    for row in board:
        bingo_num = len(set(row) & num)
        if bingo_num == len(board):
            bingo += 1
    # 세로줄 순회
    for col in board_column:
        bingo_num = len(set(col) & num)
        if bingo_num == len(board):
            bingo += 1
    # 대각선
    diagonal_1 = []
    diagonal_2 = []
    for i, row in enumerate(board):
        for j, number in enumerate(row):
                if i == j: # 좌상단에서 우하단으로 가는 빙고
                    diagonal_1.append(row[i])
                if i + j == len(board) - 1: # 우상단에서 좌하단으로 가는 빙고
                    diagonal_2.append(number)
    if len(board) == len(set(diagonal_1) & num):
        bingo += 1
    if len(board) == len(set(diagonal_2) & num):
        bingo += 1

    return bingo