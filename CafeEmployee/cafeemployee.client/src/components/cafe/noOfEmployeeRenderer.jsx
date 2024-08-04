import React from 'react';

export default (params) => {
    return (
        <a href={"employee?cafe=" + params.data.id} target="_blank">
            {params.value}
        </a>
    );
};