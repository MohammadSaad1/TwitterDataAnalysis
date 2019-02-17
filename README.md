Assignment 2

The solved part of the handin is solved in Visual Studio using the MongoDB .net driver. 
The handin is not fully solved.

1) Add following line in the top of the data document:
"polarity","_id","date","query","user","text"
2) Put the document in the bin folder in the mongodb folder.
3) Open the CMD prompt and navigate to the bin folder and add the following line:
mongoimport -d Twitter -c Tweets --type CSV --file training.1600000.processed.noemoticon --headerline

Assignment 3
Explainin the X's of the table

 Array of Ancestors:
Indexing:
Since this model navigates between descendants and ancestors through indexing, this factor fits with this model.
Large Number of Collections:
Since this model stores related data into different collections and then references between them, this factor fits with this model.
Materialized paths:
Large Number of Collections:
Since this model stores related data into different collections and then references between them, this factor fits with this model.
Shardring
Since this model references through shard keys/ strings, this facotr fits with this model.
Collection Contains Large Number of Small Documents:
Since this model splits after node of the tree into a different document, it contains a lot of small documents, and therefor it fits with this factor.
Nested sets:
	

