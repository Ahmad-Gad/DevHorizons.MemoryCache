Simple in-memory cache solution to cache any generic type of data with a unique reference key.
The engine has configuration which can be set to ignore the case of the unique reference key.

The engine has a threshold of the cached data which is the maximum value of the integer data type (2,147,483,647) but it can be congigured to accept less maximum items.
When setting new item in the cache while the cache store reached to the maximum limit, the engine will remove the least recently used item from the store to add the new entry.

This solution is thread-safe which can be used with the singleton design pattern.
For web applications, you can simply register it into the DI container using the "RegisterMemoryCache(...)" method.