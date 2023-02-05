import React from 'react';
import { CommentContainer, Container } from './styles';

export default function Comments({comments = []}) {

    if(comments.length === 0) 
    return (
        <Container>
            <p>No Comments</p>
        </Container>
    )

  return (
    <Container>
        <CommentContainer>
            <h2>Comments</h2>
            {comments.map(comment => {
                return (
                    <div key={comment.id}>
                        <hr/>
                        <h5>{comment.name} (at {new Date(comment.createdAt).toTimeString()})</h5>
                        <p>{comment.content}</p>
                    </div>
                )
            })}
        </CommentContainer>
    </Container>
  );
}
