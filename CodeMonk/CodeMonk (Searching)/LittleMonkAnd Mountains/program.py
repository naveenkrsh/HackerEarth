from array import array

arrL = array('Q')
arrR = array('Q')
arrDiff = array('Q')

input1= input().strip().split(' ')

n = int(input1[0])
q = int(input1[1])

prevValue =0
for var in list(range(n)):
    input2 = input().strip().split(' ')
    l = int(input2[0])
    r = int(input2[1])
    arrL.append(l)
    arrR.append(r)
    d = r-l
    pointRange = d+1+prevValue
    prevValue = pointRange
    arrDiff.append(pointRange)

def findIndex(x,low,high):
    if(low<high):
        if(arrDiff[0]>x):
            return 0
        mid = int(low+ (high-low)/2)
        if(arrDiff[mid]==x):
            return mid
        elif(arrDiff[mid]< x):
            if(arrDiff[mid+1]>=x):
                return mid+1
            else:
                return findIndex(x,mid+1,high)
        else:
            if(arrDiff[mid-1]<x):
                return mid
            return findIndex(x,low,mid-1)
    else:
        return 0

for var in list(range(q)):
    x = int(input())
    indexval = findIndex(x,0,n-1)
    index = int(indexval)
    a = arrDiff[index] - x
    result = arrR[index] - a
    print(result)


            
 