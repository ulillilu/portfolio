class MyStack(object):
    def __init__(self):
        self.lst = list()

    def push(self, x):
        self.lst.append(x)

    def pop(self):
        return self.lst.pop()

    def size(self):
        return len(self.lst)

class MyQueue(object):
    def __init__(self, max_size):
        self.stack1 = MyStack()
        self.stack2 = MyStack()
        self.max_size = max_size

    def qsize(self):
        return self.stack1.size() + self.stack2.size()

    def push(self, item):
        if self.stack1.size() < max_size:
            self.stack1.push(item)
            return True
        else:
            return False

    def pop(self):
        if self.stack2.size() != 0:
            return self.stack2.pop()
        else:
            if self.stack1.size() != 0:
                for _ in range(self.stack1.size()):
                    first_out = self.stack1.pop()
                    self.stack2.push(first_out)
                return self.stack2.pop()
            else:
                return False
                
n, max_size = map(int, input().strip().split(' '))
                
if __name__ == '__main__':
    queue = MyQueue(max_size)
    for i in range(n):
        cmd = input().split(' ')
        if cmd[0] == 'PUSH':
            print(queue.push(int(cmd[1])))
        elif cmd[0] == "POP":
            print(queue.pop())
        elif cmd[0] == "SIZE":
            print(queue.qsize())