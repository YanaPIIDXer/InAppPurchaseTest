class CreatePurchases < ActiveRecord::Migration[5.2]
  def change
    create_table :purchases do |t|
      t.integer :user_id, not_null: true
      t.integer :item_kind, not_null: true
      t.string :store, not_null: true
      t.string :payload, not_null: true
      t.timestamps
    end
  end
end
