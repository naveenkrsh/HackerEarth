n= int(input().strip())
inputArr = list(map(int, input().strip().split(' ')))

right = []
 
counter = 1
for y in inputArr:
    elem = (counter, y)
    right.append(elem)
    counter = counter+1


left= list(reversed(right))

def isStackEmpty(stack):
    return True if len(stack)==0 else False

def getAllNearestLargeNumber(arr):
    result = []
    stack =[]
    stack.append(arr[0])

    i =1
    arrLen = len(arr)
    while(i<arrLen):
        next = arr[i]
        if isStackEmpty(stack) == False:
            elem = stack.pop()

            while elem[1] < next[1] :
                result.append((elem[0],next[0]))
                if isStackEmpty(stack) == False:
                    elem = stack.pop()
                else:
                    break
            
            if elem[1] >= next[1] :
                stack.append(elem) 
        
        stack.append(next)    
        i= i+1
    
    while isStackEmpty(stack)== False:
        top = stack.pop()
        result.append((top[0],-1))
    
    return result

rightResult = getAllNearestLargeNumber(right)
leftResult = getAllNearestLargeNumber(left)

rightResult = sorted(rightResult,key=lambda x: x[0])
leftResult = sorted(leftResult,key=lambda x: x[0])
j=0
#print(len(rightResult))
while j<len(rightResult):
    r = rightResult[j]
    l = leftResult[j]
    final = r[1]+ l[1]
    print(final,end=" ")
    j = j+1
  