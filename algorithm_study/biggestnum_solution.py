def solution(numbers):
    num = list(map(str, numbers)) 
    # num의 인수값이 1000이하 이므로 최소 3자리수로 맞춘 뒤, 맨 앞 글자의 아스키코드를 비교
    num.sort(key=lambda x : x*3, reverse=True) 
    # 모든 값이 0일때를 처리하기 위해 int로 한번 변환
    return str(int(''.join(num)))