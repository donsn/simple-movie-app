import React from 'react';

/**
 * Displays rating as number of stars
 * @param {Number} Rating
 * @returns 
 */
export default function Rating({ rating }) {
    return (
        <div>
            <span>Rating: {rating}</span>
            <br/>
            {
                Array.from({ length: rating }, (_, i) => (
                    <span class="material-symbols-outlined" key={i}>
                        star_rate
                    </span>
                ))
            }
        </div>
    );
}
