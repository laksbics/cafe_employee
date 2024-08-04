import React from 'react';

export default (params) => {
    return (
        <span className="imgSpanLogo">
            {params.value && (
                <img
                    alt={`${params.value} Flag`}
                    src={`data:image/jpeg;base64,${params.value}`}
                    className="logo"
                />
            )}
        </span>
    );
};