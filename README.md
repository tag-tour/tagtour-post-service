#Routes (w/ bearer)
## POST /post - create post.
## GET /post/:postId - get post with postId
## PATCH /post/:postId - update post with postId
## DELETE /post/:postId - delete post with postId
## GET /post/test - test endpoint

#Request body
## POST /post  
```{
  "title": "abobbba",
  "description": "string",
  "media": [
    "string"
  ],
  "tags": [
    "string"
  ]
}
```
## PATCH /post/:postId
```{
  "title": "zhopa",
  "description": "string",
  "media": [
    "string"
  ],
  "tags": [
    "string"
  ]
}
```
#Response body
## POST /post 
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
## PATCH /post/:postId
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
