input1 = input().strip().split(' ')
n = int(input1[0])
x = int(input1[1])
arr = list(map(int, input().strip().split(' ')))

queue = []

counter = 1
for y in arr:
    elem = (counter, y)
    queue.append(elem)
    counter = counter+1

from operator import itemgetter


def getMax(smallqueue):
    maxelem = max(smallqueue, key=itemgetter(1))
    return maxelem


def dequeue():
    queue_length = len(queue)
    if queue_length < x:
        new_queue = queue[:]
        del queue[:]
        return new_queue
    else:
        new_queue = queue[:x]
        del queue[:x]
        return new_queue


def deductPower(elem):
    if elem[1] > 0:
        return(elem[0],elem[1]-1)
    else:
        return elem


processCounter = 1
while(processCounter <= x):
    new_queue = dequeue()
    #print(new_queue)
    maxelem = getMax(new_queue)
    print(maxelem[0], end=" ")
    new_queue.remove(maxelem)
    new_queue = list(map(deductPower, new_queue))
    queue = queue+new_queue
    processCounter= processCounter+1
