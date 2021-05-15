class User < ApplicationRecord
    has_many :purchases, dependent: :destroy, foreign_key: "user_id"
end
