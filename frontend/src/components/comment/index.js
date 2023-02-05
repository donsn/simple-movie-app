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
            {comments.map(comment => {
                return (
                    <div key={comment.id}>
                        <hr/>
                        <h5>{comment.name}</h5>
                        <p>{comment.comment}</p>
                    </div>
                )
            })}
        </CommentContainer>
    </Container>
  );
}
