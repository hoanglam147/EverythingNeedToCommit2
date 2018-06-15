import json
from bittrex import *
my_api_key= '86f728a98261477981e280cf38bf6d3d'
my_secret_key = 'c162b4da381e46cb9adb37e273e2231a'
myinfo = ''
x = Bittrex(my_api_key, my_secret_key)
#this is test part
#----------------------------------------------#
f = open('output.txt','w')
f.write(json.dumps(x.get_deposit_address('ETH')))
f.close()

#file = open('output.txt', 'r')
#contents = file.read()
#newcontents = contents.replace(',','\r\n')
#newcontents = newcontents.replace('{"', '{\r\n"')
#newcontents = newcontents.replace('"}', '"\r\n}')
#file.close()
#file = open('output.txt', 'w')
#file.write(newcontents)
#file.close()
#----------------------------------------------#
