Assignment 2+3.

The solved part of the handin is solved in Visual Studio using the MongoDB .net driver. 
The handin is not fully solved.

1) Add following line in the top of the data document:
"polarity","_id","date","query","user","text"
2) Put the document in the bin folder in the mongodb folder.
3) Open the CMD prompt and navigate to the bin folder and add the following line:
mongoimport -d Twitter -c Tweets --type CSV --file training.1600000.processed.noemoticon --headerline
