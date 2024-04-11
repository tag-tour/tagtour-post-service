# Bearer example
## Header 
```
{
  "alg": "HS512",
  "typ": "JWT"
}
```
## Payload 
```
{
  "Id":"2343",
  "iat": 1516239022,
  "exp":32444234234
}
```
## Key
```1231231231231231231231231231231231231231231231231231223123123123123123123231231231231231231233```
# Routes (w/ bearer)
### POST /post - create post.
### POST /post/:postId - like post with postId
### GET /post/:postId - get post with postId
### PATCH /post/:postId - update post with postId
### DELETE /post/:postId - delete post with postId
### GET /post/test - test endpoint

# Request body
### POST /post  
```{
  (Required)"title": "abobbba",
  "description": "string",
  "media": [
    "string"
  ],
  (Required)"tags": [
    "string"
  ]
}
```
### PATCH /post/:postId
```{
 (optional) "title": "ztsedsd",
  (optional)"description": "string",
  (optional)"media": [
    "string"
  ],
 (optional) "tags": [
    "string"
  ]
}
```
# Response body
### POST /post 
```{
    "data": {
        "id": 5,
        "title": "testtest",
        "description": "string",
        "media": [
            "string"
        ],
        "likes": 0,
        "author": 443,
        "tags": [
            "string"
        ],
        "createdAt": "2024-04-11T15:12:34.2146989Z"
    },
    "success": true,
    "message": "Post successfully created."
}
```
### PATCH /post/:postId
```{
    "data": {
        "id": 4,
        "title": "testtest",
        "description": "string",
        "media": [
            "string"
        ],
        "likes": 0,
        "author": 443,
        "tags": [
            "string"
        ],
        "createdAt": "2024-04-11T15:03:45.561327Z"
    },
    "success": true,
    "message": "Post successfully updated."
}
```
