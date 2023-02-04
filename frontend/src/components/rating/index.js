import React from 'react';
import { RatingsContainer } from './styles';

/**
 * Displays rating as number of stars
 * @param {Number} Rating
 * @returns 
 */
export default function Rating({ rating }) {
    return (
        <RatingsContainer>
            <span>Rating: {rating}</span>
            <br/>
            {
                Array.from({ length: rating }, (_, i) => (
                    <span class="material-symbols-outlined" key={i}>
                        star_rate
                    </span>
                ))
            }
        </RatingsContainer>
    );
}
