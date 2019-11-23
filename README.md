# alphabet-corrector
アルファベットあつめ

■GameManagerオブジェクトで基本設定ができます。
　各設定の説明はConstValue.csをご確認ください。

■Tag:Groundを地面とみなします。
　ジャンプ→待機のSprite更新や空中ジャンプ回数の回復は、
　接触したオブジェクトがTag:Groundかどうかで判断しています。
　そのため、ステージに配置する地面のTagには必ずGroundを設定してください。

■Tag:Item-AlphabetをAlphabetとみなします。
　そのため、ステージに配置するAlphabetのTagには必ずItem-Alphabetを設定してください。
