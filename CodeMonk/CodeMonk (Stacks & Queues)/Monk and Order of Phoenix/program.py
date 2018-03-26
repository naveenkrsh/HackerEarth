n = int(input().strip())

arr = []
current=[]


for a in range(0,n):
   row =list(map(int,input().strip().split(" ")))
   row.pop(0)
   arr.append(row)
   current.append(-1)

q = int(input().strip())

def clearCurrnet(k):
    for a in range(k,n):
        current[a] = -1 

def addToRow(k,h):
    k= k-1
    arr[k].append(h)
    #clearCurrnet(k)

    if(current[k]>-1):
        if k==0:
            firstRow = min(arr[0])
            current[k] = firstRow
        elif k < n-1:
            if current[k+1] < h:
                clearCurrnet(k)
            elif current[k] > h:
                current[k]=h
        else:
            if (current[k]> h):
                current[k] = h
            


    

def removeFromRow(k):
    k = k-1
    elem = arr[k].pop()
    if(len(arr[k])==0):
         clearCurrnet(k)
    elif current[k] > -1:
        if current[k] == elem:
            if k==0:
                nextgt = min(arr[0])
                current[k] = nextgt
                if current[k] > current[k+1]:
                    clearCurrnet(k+1)
            else :
                rowend = len(arr[k])-1
                nexgt = findNextGreater(arr[k],arr[k-1],0,rowend)
                current[k] = nexgt
                if(nexgt>current[k+1]) or nexgt==-1:
                    clearCurrnet(k)
            

    
    


def findNextGreater(rowArr,value,low,high):
    if low<high :
        mid = low + int((high-low)/2)
        
        if rowArr[mid]== value:
            #return rowArr[mid]
            if rowArr[mid+1] > value:
                return rowArr[mid+1]
            return findNextGreater(rowArr,value,mid+1,high)
        elif rowArr[mid]< value:
            if rowArr[mid+1] > value:
                return rowArr[mid+1]
            return findNextGreater(rowArr,value,mid+1,high)
        else:
            # if rowArr[mid-1] > value:
            #     return rowArr[mid-1]
            return findNextGreater(rowArr,value,low,mid)
    else:
        return -1
        


def canUseSpecialWand():

    if (-1 in current)== False :
        print("YES")
        return 0

    if current[0]==-1:
        firstRow = min(arr[0])
        current[0] = firstRow
    else :
        firstRow = current[0]

    nextGreater = firstRow
    for a in range(1,n):

        if current[a] != -1:
            continue

        if arr[a][0] > nextGreater:
            current[a]= nextGreater
            continue

        rowend = len(arr[a])-1

        if arr[a][rowend] < nextGreater:
            nextGreater=-1
            current[a]=nextGreater
            break

        nextGreater = findNextGreater(arr[a],nextGreater,0,rowend)
        current[a]=nextGreater
        

    # if nextGreater != -1:
    #     print("YES")
    if (-1 in current)== True :
        print("NO")
    else:
        print("YES")


for i in range(0,q):
    operation = list(map(int,input().strip().split(" ")))

    if operation[0]== 1:
        addToRow(operation[1],operation[2])
    elif operation[0]==0:
        removeFromRow(operation[1])
    else :
        canUseSpecialWand()
   
